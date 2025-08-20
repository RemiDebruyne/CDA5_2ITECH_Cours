package com.example.exo_3.controllers;

import com.example.exo_3.CartDto.CartDto;
import com.example.exo_3.entities.Product;
import com.example.exo_3.sevices.CartService;
import com.example.exo_3.sevices.ProductService;
import jakarta.servlet.http.HttpSession;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.Map;

@RestController
@RequestMapping("/api/carts")
public class CartController {
    private final ProductService productService;
    private final CartService cartService;
    private HttpSession session;

    public CartController(ProductService productService, HttpSession session,  CartService cartService) {
        this.productService = productService;
        this.session = session;
        this.cartService = cartService;
    }

    @GetMapping("/{productId}")
    public Map<Integer, Integer> addProduct(@PathVariable int productId) {
        cartService.add(productId);
        return (Map<Integer, Integer>) session.getAttribute("cart");
    }

    @GetMapping
    public ResponseEntity<CartDto> getCart() {
        var cart =  (Map<Integer, Integer>)session.getAttribute("cart");
        var products = cartService.getAllProducts(cart).stream().map(product -> product.getName()).toList();
        var totalPrice = cartService.getTotalPrice(cart);
        return ResponseEntity.ok(CartDto.MapCartToDto(products, totalPrice));
    }
}
