import 'package:flutter/material.dart';
import '../constants/colors_constant.dart' as colors_constant;

class CustomCheckbox extends StatefulWidget {
  final String label;
  bool isChecked = false;
  final VoidCallback onChange;

  const CustomCheckbox({
    super.key,
    required this.label,
    required this.onChange,
  });

  @override
  State<CustomCheckbox> createState() => _CustomCheckboxState();
}

class _CustomCheckboxState extends State<CustomCheckbox> {
  void toggleCheckbox() {
    setState(() {
      widget.isChecked = !widget.isChecked;
    });
  }

  @override
  Widget build(BuildContext context) {
    return InkWell(
      onTap: toggleCheckbox,
      child: Container(
        decoration: BoxDecoration(
          color: widget.isChecked
              ? Theme.of(context).primaryColor
              : Colors.grey[300],
          borderRadius: BorderRadius.all(Radius.circular(30)),
          border: BoxBorder.all(color: colors_constant.lightGray),
        ),
        child: Text(
          widget.label,
          style: TextStyle(
            color: widget.isChecked ? Colors.white : colors_constant.lightGray,
          ),
        ),
      ),
    );
  }
}
