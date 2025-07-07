import 'dart:math';

enum Activity {
  running("blue", "Running gives you 2 points.", 2),
  biking("red", "biking gives you 4 points", 4),
  swimming("green", "swimming gives you 25 points", 25),
  climbing("purple", "rock climbing gives you 100000 points", 10000000);

  final String color;
  final String description;
  final int point;

  const Activity(this.color, this.description, this.point);

  static String sumup(Activity activity) {
    return activity.description;
  }

  static int getAllPoints() {
    int sum = 0;
    for (var activity in Activity.values) {
      sum += activity.point;
    }

    return sum;
  }

  static void getAllStats(List<Activity> activities) {
    for (var activity in activities) {
      print(sumup(activity));
    }
    print("\n");
    print('total points: ${getAllPoints()} \n');
    print("Statistics:");
    for (var activity in activities) {
      int times = Random().nextInt(10);
      print(
        '- ${activity} : ${times > 1 ? '${times} times' : '${times} time'}',
      );
    }
  }
}

void main(List<String> arguments) {
  Activity.getAllStats([
    Activity.running,
    Activity.biking,
    Activity.swimming,
    Activity.climbing,
  ]);
}
