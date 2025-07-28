import 'package:flutter/material.dart';
import 'package:tp_tinder/widgets/custom_checkbox.dart';

class GenderInput extends StatefulWidget {
  const GenderInput({super.key});

  @override
  State<GenderInput> createState() => _GenderInputState();
}

class _GenderInputState extends State<GenderInput> {
  String? value;

  @override
  Widget build(BuildContext context) {
    return Row(
      children: [
        CustomCheckbox(label: "Homme"),
        CustomCheckbox(label: "Femme"),
      ],
    );
  }
}
