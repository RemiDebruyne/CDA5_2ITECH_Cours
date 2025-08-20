package com.example.exo_3.sevices;

import com.example.exo_3.entities.Product;
import jakarta.servlet.http.HttpSession;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

@Service
public class CartService {
    private HttpSession session;
    private ProductService productService;

    public CartService(HttpSession session, ProductService productService) {
        this.session = session;
        this.productService = productService;
    }

    public void add(int productId) {
        Map<Integer, Integer> cart = (Map<Integer, Integer>) session.getAttribute("cart");
        if (cart == null) {
            cart = new HashMap<>();
        }
        if (cart.containsKey(productId)) {
            cart.put(productId, cart.get(productId) + 1);
        } else {
            cart.put(productId, 1);
        }

        session.setAttribute("cart", cart);
    }

    public void remove(Product product) {
        Map<Integer, Integer> cart = (Map<Integer, Integer>) session.getAttribute("cart");

        if (cart == null) {
            return;
        }

        if (cart.containsKey(product.getId()) && cart.get(product.getId()) > 1) {
            cart.put(product.getId(), cart.get(product.getId()) - 1);
        } else {
            cart.remove(product.getId());
        }
        session.setAttribute("cart", cart);
    }

    public Map<Integer, Integer> getCart() {
        return (Map<Integer, Integer>) session.getAttribute("cart");
    }

    public List<Product> getAllProducts(Map<Integer, Integer> cart){
        var products = new ArrayList<Product>();
        for(var entry : cart.entrySet()){
            Product product = productService.getProductById(entry.getKey());
            products.add(product);
        }
        return products;
    }

    public double getTotalPrice() {
        var cart =  (Map<Integer, Integer>) session.getAttribute("cart");

        if (cart == null) {
            return 0;
        }

        double totalPrice = 0;

        for (var entry : cart.entrySet()) {
            Product product = productService.getProductById(entry.getKey());
            totalPrice += (product.getPrice() * entry.getValue());
        }
        return totalPrice;
    }
    public double getTotalPrice(Map<Integer, Integer> cart) {
        cart =  (Map<Integer, Integer>) session.getAttribute("cart");

        if (cart == null) {
            return 0;
        }

        double totalPrice = 0;

        for (var entry : cart.entrySet()) {
            Product product = productService.getProductById(entry.getKey());
            totalPrice += (product.getPrice() * entry.getValue());
        }
        return totalPrice;
    }
}
