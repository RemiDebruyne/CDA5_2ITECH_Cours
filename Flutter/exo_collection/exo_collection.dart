List<String> artists = ["Nf", "Taylor Swift", "Lin Manuel Miranda"];

void addMusicGenre(String artist) {
  artists.add(artist);
}

void readFirstArtist() {
  print(artists.first);
}

void readLastArtist() {
  print(artists.last);
}

void removeArtist(String artist) {
  artists.remove(artist);
}

void readAllArtist() {
  for (var artist in artists) {
    print(artist);
  }
}

Set<String> categories = {"pop", "rock", "rap"};

void addCategory(String category) {
  categories.add(category);
}

void removeCategory(String category) {
  categories.remove(category);
}

void verifyCategoryExist(String category) {
  categories.contains(category);
}

void readAllCategory() {
  for (var category in categories) {
    print(category);
  }
}

Map<String, dynamic> events = {
  "super event 1": {
    "nom": "super event",
    "lieu": "quelque part",
    "date": "un jour",
    "artistes": ["jean pierre"],
  },
};

void addEvent(String eventName, Map<String, dynamic> event) {
  events[eventName] = {};
  for (String field in event.keys) {
    events[eventName][field] = event[field];
  }
}

void updateEvent(String event, String fieldToUpdate, String value) {
  events[event][fieldToUpdate] = value;
  // events.update(event, (events[event]) => {
  //   ...events[event],
  //   fieldToUpdate : value
  // });
}

void removeEvent(String event) {
  events.remove(event);
}

void readEvent() {
  for (var event in events.keys) {
    print(events[event]);
  }
}

void getAllArtistFromEvent() {
  List<String> artists = [];
  for (var event in events.keys) {
    for (var artist in events[event]["artistes"]) {
      artists.add(artist);
    }
  }

  print(artists);
}

Map<String, List<String>> scenes = {
  "scène 1": ["jean", "jean 2"],
  "scène 2": [],
};

void getAllArtistFromScene() {
  for (var scene in scenes.keys) {
    for (var artist in scenes[scene]!) {
      print(artist);
    }
  }
}

void addArtistToScene(String scene, String artist) {
  scenes[scene]!.add(artist);
}

void removeArtistFromScene(String scene, String artist) {
  scenes[scene]!.remove(artist);
}

void main(List<String> arguments) {
  addEvent("event 2", {
    "nom": "test nom",
    "date": "test date",
    "artistes": ["test", "test 2"],
  });
  // readEvent();
  addArtistToScene("scène 2", "fred");
  removeArtistFromScene("scène 1", "jean");
  // getAllArtistFromEvent();
  getAllArtistFromScene();
}
