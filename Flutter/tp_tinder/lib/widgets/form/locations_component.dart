import 'package:flutter/material.dart';
import '../../constants/font_constant.dart' as fontsize_constant;
import '../../constants/colors_constant.dart' as colors_constant;

class Location extends StatefulWidget {
  const Location({super.key});

  @override
  State<Location> createState() => _LocationState();
}

class _LocationState extends State<Location> {
  final locationController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Column(
      spacing: 10,
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        Text(
          "Location",
          style: TextStyle(
            fontSize: fontsize_constant.fontSize,
            fontWeight: FontWeight.bold,
          ),
        ),
        TextField(
          controller: locationController,
          decoration: InputDecoration(
            hintText: "Paris, Lille",
            enabledBorder: OutlineInputBorder(
              borderRadius: BorderRadius.all(Radius.circular(30)),
              borderSide: BorderSide(color: colors_constant.lightGray),
            ),
            prefixIcon: Icon(
              Icons.pin_drop,
              color: Theme.of(context).primaryColor,
            ),
          ),
        ),
      ],
    );
  }
}
