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
        body: Padding(padding: EdgeInsets.all(16), child: InteractifForm()),
      ),
    );
  }
}

class InteractifForm extends StatefulWidget {
  const InteractifForm({super.key});
  @override
  State<InteractifForm> createState() => _InteractifFormState();
}

class _InteractifFormState extends State<InteractifForm> {
  bool isFormValid() {
    int? age = int.tryParse(ageController.text) ?? 0;
    return accepteConditions &&
        age > 18 &&
        mdpController.text.contains(RegExp("[0-9]"));
  }

  // Contrôleurs pour les champs texte
  final nomController = TextEditingController();
  final emailController = TextEditingController();
  final mdpController = TextEditingController();
  final ageController = TextEditingController();

  // Genre sélectionné
  String? genre;
  String? pays;

  // Checkbox: Conditons acceptées
  bool accepteConditions = false;

  void _soumettreFormulaire() {
    print('Nom: ${nomController.text}');
    print('Email: ${emailController.text}');
    print('email: ${mdpController.text}');
    print('Genre: $genre');
    print('Conditions: $accepteConditions');
    print('Pays: $pays');
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text('Formulaire interactif')),
      body: ListView(
        children: [
          Text("Nom"),
          TextField(controller: nomController),

          SizedBox(height: 16),

          Text("Email"),
          TextField(
            controller: emailController,
            keyboardType: TextInputType.emailAddress,
          ),

          Text("Age"),
          TextField(
            controller: ageController,
            keyboardType: TextInputType.number,
          ),

          Text("Mot de passe"),
          TextField(controller: mdpController, obscureText: true),

          SizedBox(height: 16),

          Text('Genre'),
          DropdownButton<String>(
            value: genre,
            isExpanded: true,
            items: [
              DropdownMenuItem(value: "Homme", child: Text("Homme")),
              DropdownMenuItem(value: "Femme", child: Text("Femme")),
              DropdownMenuItem(value: "Autre", child: Text("Autre")),
            ],
            onChanged: (value) {
              setState(() {
                genre = value;
              });
            },
          ),

          // Row(
          //   children: [
          //     Radio(
          //       value: 'Homme',
          //       groupValue: genre,
          //       onChanged: (value) {
          //         setState(() {
          //           genre = value;
          //         });
          //       },
          //     ),
          //     Text('Homme'),
          //     Radio(
          //       value: 'Femme',
          //       groupValue: genre,
          //       onChanged: (value) {
          //         setState(() {
          //           genre = value;
          //         });
          //       },
          //     ),
          //     Text('Femme'),
          //   ],
          // ),

          // SizedBox(height: 16),

          // Row(
          //   children: [
          //     Checkbox(
          //       value: accepteConditions,
          //       onChanged: (value) {
          //         setState(() {
          //           accepteConditions = value ?? false;
          //         });
          //       },
          //     ),
          //     Text("J'accepte les conditions d'utilisation"),
          //   ],
          // ),
          SizedBox(height: 16),

          Text('Pays'),
          DropdownButton<String>(
            value: pays,
            isExpanded: true,
            items: [
              DropdownMenuItem(value: 'fr', child: Text('France')),
              DropdownMenuItem(value: 'be', child: Text('Belgique')),
              DropdownMenuItem(value: 'ch', child: Text('Suisse')),
            ],
            onChanged: (value) {
              setState(() {
                pays = value;
              });
            },
            hint: Text('Sélectionnez un pays'),
          ),

          Row(
            children: [
              Checkbox(
                value: accepteConditions,
                onChanged: (value) {
                  setState(() {
                    accepteConditions = value ?? false;
                  });
                },
              ),
              Text("J'accepte les conditions d'utilisation"),
            ],
          ),

          SizedBox(height: 24),

          ElevatedButton(
            onPressed: isFormValid() ? _soumettreFormulaire : null,
            child: Text('Envoyer'),
          ),
        ],
      ),
    );
  }
}
