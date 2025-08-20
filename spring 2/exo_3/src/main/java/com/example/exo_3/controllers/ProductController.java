package com.example.exo_3.controllers;

import com.example.exo_3.entities.Product;
import com.example.exo_3.repositories.IProductRepository;
import com.example.exo_3.sevices.CartService;
import com.example.exo_3.sevices.ProductService;
import jakarta.servlet.http.HttpSession;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

@RestController
@RequestMapping("/api/products")
public class ProductController {

    private final ProductService productService;

    public ProductController(ProductService productService) {
        this.productService = productService;
    }

    @GetMapping
    public List<Product> getAll(){
        return productService.getAll();
    }

    @GetMapping("/{id}")
    public Product getById(@PathVariable Integer id){
     return productService.getProductById(id);
    }

    @PostMapping
    public Product create(@RequestBody Product product){
        return productService.add(product);
    }

    @DeleteMapping("/{id}")
    public void delete(@PathVariable Integer id){
        productService.delete(id);
    }
}
