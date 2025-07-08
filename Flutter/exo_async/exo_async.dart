import 'dart:io';

String askName() {
  print("What's your name ?");
  return stdin.readLineSync() ?? "";
}

String askDrink() {
  print("What drink do you want ?");
  print("""
  1 - coffee
  2 - tea
  3 - hot chocolate
  4 - cold drink
""");
  String userChoice = stdin.readLineSync() ?? "";
  String drink = "";
  switch (userChoice) {
    case "1":
      drink = "coffee";
      break;
    case "2":
      drink = "tea";
      break;
    case "3":
      drink = "hot chocolate";
      break;
    case "4":
      drink = "cold drink";
    default:
      drink = "";
  }

  return drink;
}

Future<void> greetings(String name, String drink) async {
  // print('Welcome ${name}, you\'re ${drink} is being prepared');
  await Future.delayed(Duration(seconds: 2));
}

Future<void> prepareDrink(String drink) async {
  try {
    // print('Preparing ${drink}...');
    await Future.delayed(Duration(seconds: 5));
  } catch (e) {
    print("An problem occured while preparing your drink");
  }
}

Future<void> mixing() async {
  try {
    // print('Mixing the ingredients...');
    await Future.delayed(Duration(seconds: 5));
  } catch (e) {
    print("A problem occured while mixing the ingredient");
  }
}

Future<void> warmingUp(String drink) async {
  // print('Warming up your ${drink}...');
  await Future.delayed(Duration(seconds: 3));
}

Future<void> finishing(String drink) async {
  // print('Finishing your ${drink}');
  await Future.delayed(Duration(seconds: 3));
}

void ready(String name, String drink) {
  print('${name}, your ${drink} is ready ! Enjoy !');
}

Stream<String> orderDrink(String name, String drink) async* {
  yield 'Welcome ${name}, you\'re ${drink} is being prepared';
  await greetings(name, drink);
  yield 'Preparing ${drink}...';
  await prepareDrink(drink);
  yield 'Mixing the ingredients...';
  await mixing();
  if (drink != "cold drink") {
    yield 'Warming up your ${drink}...';
    await warmingUp(drink);
  }
  yield 'Finishing your ${drink}';
  await finishing(drink);
  yield '${name}, your ${drink} is ready ! Enjoy !';
}

void main(List<String> arguments) async {
  String name = askName();
  String drink = askDrink();

  await for (String steps in orderDrink(name, drink)) {
    print(steps);
  }
}
