import 'package:exo_grid_list/main_page_text.dart';
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
        body: Stack(
          children: [
            BackgroundImage(),
            Center(
              child: Column(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  // Image.network(""),
                  //Fake image
                  Container(
                    height: 300,
                    width: 250,
                    decoration: BoxDecoration(color: Colors.lightGreen),
                  ),
                  MainPageText(),
                ],
              ),
            ),
          ],
        ),
      ),
    );
  }
}

class BackgroundImage extends StatelessWidget {
  const BackgroundImage({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: const Color.fromARGB(255, 255, 230, 7),
      body: Container(
        height: 300,
        decoration: BoxDecoration(
          color: Colors.white,
          borderRadius: BorderRadius.only(
            bottomLeft: Radius.circular(500),
            bottomRight: Radius.circular(500),
          ),
        ),
      ),
    );
  }
}
