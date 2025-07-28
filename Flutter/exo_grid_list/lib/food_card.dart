import 'package:flutter/material.dart';

class FoodCard extends StatelessWidget {
  const FoodCard({super.key});

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Container(
          width: 140,
          height: 140,
          decoration: BoxDecoration(
            color: Colors.pink,
            borderRadius: BorderRadius.only(
              topLeft: Radius.circular(15),
              topRight: Radius.circular(15),
            ),
          ),
          child: const Icon(
            Icons.food_bank_rounded,
            color: Colors.white,
            size: 50,
          ),
        ),
        Container(
          width: 140,
          height: 40,
          decoration: BoxDecoration(
            color: Color.fromARGB(255, 253, 229, 8),
            borderRadius: BorderRadius.only(
              bottomLeft: Radius.circular(15),
              bottomRight: Radius.circular(15),
            ),
          ),
          child: Row(
            mainAxisAlignment: MainAxisAlignment.center,
            crossAxisAlignment: CrossAxisAlignment.center,
            children: [Text("Lorem ipsum", style: TextStyle(fontSize: 10))],
          ),
        ),
      ],
    );
  }
}
