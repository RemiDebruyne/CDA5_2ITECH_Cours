package com.example.exo_3.CartDto;

import com.example.exo_3.entities.Product;
import com.example.exo_3.sevices.CartService;
import com.example.exo_3.sevices.ProductService;
import lombok.*;

import java.util.List;
import java.util.Map;

@Data
@Getter
@Setter
@AllArgsConstructor
@NoArgsConstructor
@Builder
public class CartDto {
    private List<String> products;
    private double totalPrice;

    public static CartDto MapCartToDto(List<String> products, double totalPrice) {
        return CartDto.builder().products(products).totalPrice(totalPrice).build();
    }
}
