import 'dart:io';

enum Drink {
  coffee(
    Duration(seconds: 2),
    Duration(seconds: 4),
    Duration(seconds: 3),
    Duration(seconds: 2),
  ),
  hotChocolate(
    Duration(seconds: 2),
    Duration(seconds: 4),
    Duration(seconds: 3),
    Duration(seconds: 2),
  ),
  tea(
    Duration(seconds: 2),
    Duration(seconds: 3),
    Duration(seconds: 3),
    Duration(seconds: 2),
  ),
  coldDrink(
    Duration(seconds: 2),
    Duration(seconds: 1),
    Duration(seconds: 0),
    Duration(seconds: 2),
  );

  final Duration preparationTime;
  final Duration mixingTime;
  final Duration warmingUpTime;
  final Duration finishingTime;

  const Drink(
    this.preparationTime,
    this.mixingTime,
    this.warmingUpTime,
    this.finishingTime,
  );
}

String askName() {
  print("What's your name ?");
  return stdin.readLineSync() ?? "";
}

Drink? askDrink() {
  print("What drink do you want ?");
  print("""
  1 - coffee
  2 - tea
  3 - hot chocolate
  4 - cold drink
""");
  String userChoice = stdin.readLineSync() ?? "";
  Drink? drink = null;
  switch (userChoice) {
    case "1":
      drink = Drink.coffee;
      break;
    case "2":
      drink = Drink.tea;
      break;
    case "3":
      drink = Drink.hotChocolate;
      break;
    case "4":
      drink = Drink.coldDrink;
    default:
      drink = null;
  }

  return drink;
}

Future<void> greetings(String name, Drink drink) async {
  // print('Welcome ${name}, you\'re ${drink} is being prepared');
  await Future.delayed(Duration(seconds: 2));
}

Future<void> prepareDrink(Drink drink) async {
  try {
    // print('Preparing ${drink}...');
    await Future.delayed(drink.preparationTime);
  } catch (e) {
    print("An problem occured while preparing your drink");
  }
}

Future<void> mixing(Drink drink) async {
  try {
    // print('Mixing the ingredients...');
    await Future.delayed(drink.mixingTime);
  } catch (e) {
    print("A problem occured while mixing the ingredient");
  }
}

Future<void> warmingUp(Drink drink) async {
  // print('Warming up your ${drink}...');
  try {
    await Future.delayed(drink.warmingUpTime);
  } catch (e) {
    print("A problem occured while warmingup your drink");
  }
}

Future<void> finishing(Drink drink) async {
  // print('Finishing your ${drink}');
  try {
    await Future.delayed(drink.finishingTime);
  } catch (e) {
    print("A problem occured while finishing your drink");
  }
}

void ready(String name, Drink drink) {
  print('${name}, your ${drink} is ready ! Enjoy !');
}

Stream<String> orderDrink(String name, Drink drink) async* {
  yield 'Welcome ${name}, you\'re ${drink.name} is being prepared';
  await greetings(name, drink);
  yield 'Preparing ${drink.name}...';
  await prepareDrink(drink);
  yield 'Mixing the ingredients...';
  await mixing(drink);
  if (drink != "cold drink") {
    yield 'Warming up your ${drink.name}...';
    await warmingUp(drink);
  }
  yield 'Finishing your ${drink.name}';
  await finishing(drink);
  yield '${name}, your ${drink.name} is ready ! Enjoy !';
}

File generateLogFile() {
  return File(
    './${DateTime.now().toString().replaceAll(":", "-").replaceAll(" ", "_")}_log.txt',
  );
}

void main(List<String> arguments) async {
  var file = generateLogFile();

  String name = askName();
  Drink? drink = askDrink();

  while (drink == null) {
    print("An error occured while selectin your drink, please try again");
    drink = askDrink();
  }

  await for (String steps in orderDrink(name, drink)) {
    print(steps);
    await file.writeAsString(
      '${DateTime.now()}: ${steps}',
      mode: FileMode.append,
    );
  }
}
