import 'package:flutter/material.dart';
import 'package:tp_tinder/widgets/form/locations_component.dart';
import './constants/colors_constant.dart' as colors;

void main() {
  runApp(const MainApp());
}

class MainApp extends StatelessWidget {
  const MainApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      theme: ThemeData(
        primaryColor: Color.fromARGB(255, 250, 50, 113),
        useMaterial3: true,
      ),
      home: Scaffold(
        body: Center(child: Column(children: [Location()])),
      ),
    );
  }
}
