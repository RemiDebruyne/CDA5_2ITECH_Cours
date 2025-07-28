import 'package:exo_grid_list/list_page.dart';
import 'package:flutter/material.dart';

class MainPageText extends StatelessWidget {
  const MainPageText({super.key});

  @override
  Widget build(BuildContext context) {
    return Expanded(
      child: Column(
        children: [
          Padding(
            padding: const EdgeInsets.only(top: 30),
            child: Text(
              "Menu".toUpperCase(),
              style: TextStyle(
                fontSize: 100,
                color: Colors.pink,
                fontWeight: FontWeight.bold,
                height: 0.8,
              ),
            ),
          ),
          Text(
            "Restaurant".toUpperCase(),
            style: TextStyle(fontSize: 35, fontWeight: FontWeight.bold),
          ),
          SizedBox(
            width: 200,
            child: Padding(
              padding: const EdgeInsets.only(top: 10, bottom: 30),
              child: Text(
                "Let us help your discover the best food",
                style: TextStyle(fontWeight: FontWeight.bold),
                textAlign: TextAlign.center,
              ),
            ),
          ),
          ElevatedButton(
            style: ElevatedButton.styleFrom(
              minimumSize: Size(300, 40),
              backgroundColor: Colors.pink,
              foregroundColor: Colors.white,
            ),
            onPressed: () {
              Navigator.push(
                context,
                MaterialPageRoute(builder: (context) => const ListPage()),
              );
            },
            child: Text("Get started"),
          ),
        ],
      ),
    );
  }
}
