import 'package:flutter/material.dart';

void main() {
  runApp(const MainApp());
}

class MainApp extends StatelessWidget {
  const MainApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: Scaffold(
        body: Center(
          child: Padding(
            padding: EdgeInsetsGeometry.all(10),
            child: Column(
              children: [
                Padding(
                  padding: EdgeInsetsGeometry.fromLTRB(0, 20, 0, 20),
                  child: Text('Fiche produit'),
                ),
                Expanded(
                  child: Column(
                    children: [
                      Container(
                        height: 600,
                        padding: EdgeInsets.all(8.0),
                        color: const Color.fromARGB(255, 255, 255, 255),
                        child: Row(
                          crossAxisAlignment: CrossAxisAlignment.start,
                          spacing: 25,
                          children: [
                            Image.network(
                              height: 100.00,
                              "https://img01.ztat.net/article/spp-media-p1/892238ea2d574a8b8f0a503f6f539d2d/e75a303d0c44411fbb260d5277c6c8b6.jpg?imwidth=1800&filter=packshot",
                            ),
                            Column(
                              spacing: 5,
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                Text("Sneaker beige"),
                                Text(
                                  style: TextStyle(color: Colors.green),
                                  "59,99€",
                                ),
                                Container(
                                  padding: EdgeInsets.all(8.0),
                                  color: Colors.blue,
                                  child: Row(
                                    children: [
                                      Icon(Icons.shopping_cart),
                                      Text(
                                        style: TextStyle(color: Colors.white),
                                        "Acheter",
                                      ),
                                    ],
                                  ),
                                ),
                              ],
                            ),
                          ],
                        ),
                      ),
                    ],
                  ),
                ),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
