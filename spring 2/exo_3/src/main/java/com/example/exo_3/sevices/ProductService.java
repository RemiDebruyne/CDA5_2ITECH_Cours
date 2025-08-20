package com.example.exo_3.sevices;

import com.example.exo_3.entities.Product;
import com.example.exo_3.repositories.IProductRepository;
import jakarta.servlet.http.HttpSession;
import org.springframework.stereotype.Service;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

@Service
public class ProductService {
    private IProductRepository productRepository;

    public ProductService(IProductRepository productRepository) {
        this.productRepository = productRepository;
    }

    public Product getProductById(int id) {
        return productRepository.getById(id);
    }

    public Product add(Product product) {
        return productRepository.save(product);
    }

    public List<Product> getAll() {
        return productRepository.findAll();
    }

    public Product updateProduct(Product product) {
        var oldproduct = productRepository.getById(product.getId());
        oldproduct.setName(product.getName());
        oldproduct.setPrice(product.getPrice());
        return productRepository.save(oldproduct);
    }

    public void delete(int id) {
        var productToDelete = productRepository.getById(id);
        productRepository.delete(productToDelete);
    }


}
