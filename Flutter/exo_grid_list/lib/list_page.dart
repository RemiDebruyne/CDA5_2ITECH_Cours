import 'package:exo_grid_list/food_card.dart';
import 'package:flutter/material.dart';

class ListPage extends StatelessWidget {
  const ListPage({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: const Color.fromARGB(255, 216, 12, 80),
      body: Stack(
        children: [
          // 🧱 Le contenu principal avec marge basse pour ne pas cacher les éléments
          Column(
            children: [
              const ListPageHeader(),
              const Expanded(child: ListPageGrid()),
            ],
          ),
          // 🚧 Navbar superposée en bas
          const Positioned(
            left: 0,
            right: 0,
            bottom: 0,
            child: ListPageNavbar(),
          ),
        ],
      ),
    );
  }
}

class ListPageHeader extends StatelessWidget {
  const ListPageHeader({super.key});

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.fromLTRB(16, 16, 16, 40),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Text("Hi Jean", style: TextStyle(color: Colors.white, fontSize: 24)),
          Text(
            "Grab your delicous meal !",
            style: TextStyle(color: Colors.white),
          ),
          Padding(
            padding: const EdgeInsets.fromLTRB(0, 10, 0, 0),
            child: Container(
              decoration: BoxDecoration(
                color: Colors.white,
                borderRadius: BorderRadius.all(Radius.circular(10)),
              ),
              child: Padding(
                padding: EdgeInsetsGeometry.fromLTRB(10, 5, 0, 5),
                child: Row(
                  spacing: 6,
                  children: [Icon(Icons.search), Text("Search")],
                ),
              ),
            ),
          ),
        ],
      ),
    );
  }
}

// class ListPageGrid extends StatelessWidget {
//   const ListPageGrid({super.key});

//   @override
//   Widget build(BuildContext context) {
//     return Container(
//       decoration: BoxDecoration(
//         color: Colors.white,
//         borderRadius: BorderRadius.only(
//           topLeft: Radius.circular(40),
//           topRight: Radius.circular(40),
//         ),
//       ),
//       child: Column(
//         crossAxisAlignment: CrossAxisAlignment.start,
//         children: [
//           Padding(
//             padding: const EdgeInsets.all(25),
//             child: Text("Recommended"),
//           ),
//           GridView.builder(
//             gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
//               crossAxisCount: 2,
//               crossAxisSpacing: 10,
//               mainAxisSpacing: 25,
//             ),
//             itemCount: 10,
//             itemBuilder: (context, index) {
//               return FoodCard();
//             },
//           ),
//         ],
//       ),
//     );
//   }
// }

class ListPageGrid extends StatelessWidget {
  const ListPageGrid({super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      decoration: const BoxDecoration(
        color: Colors.white,
        borderRadius: BorderRadius.only(
          topLeft: Radius.circular(40),
          topRight: Radius.circular(40),
        ),
      ),
      child: Padding(
        padding: const EdgeInsets.all(20),
        child: CustomScrollView(
          slivers: [
            // Texte "Recommended"
            SliverToBoxAdapter(
              child: Padding(
                padding: const EdgeInsets.only(bottom: 20),
                child: Text(
                  "Recommended",
                  style: Theme.of(context).textTheme.titleMedium,
                ),
              ),
            ),

            // Grille d’éléments
            SliverGrid(
              delegate: SliverChildBuilderDelegate(
                (context, index) => FoodCard(),
                childCount: 10,
              ),
              gridDelegate: const SliverGridDelegateWithFixedCrossAxisCount(
                crossAxisCount: 2,
                crossAxisSpacing: 10,
                mainAxisSpacing: 25,
              ),
            ),
          ],
        ),
      ),
    );
  }
}

class ListPageNavbar extends StatelessWidget {
  const ListPageNavbar({super.key});

  @override
  Widget build(BuildContext context) {
    return Container(
      height: 80,
      decoration: BoxDecoration(
        borderRadius: BorderRadius.only(
          topLeft: Radius.circular(20),
          topRight: Radius.circular(20),
        ),
        color: const Color.fromARGB(255, 230, 230, 230),
      ),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceAround,
        children: [
          Container(
            width: 50,
            height: 50,
            decoration: BoxDecoration(
              color: Colors.pink,
              shape: BoxShape.circle,
            ),
            child: Icon(Icons.home_outlined, color: Colors.white),
          ),
          Container(
            width: 50,
            height: 50,
            decoration: BoxDecoration(
              color: Colors.pink,
              shape: BoxShape.circle,
            ),
            child: Icon(Icons.add, color: Colors.white),
          ),
          Container(
            width: 50,
            height: 50,
            decoration: BoxDecoration(
              color: Colors.pink,
              shape: BoxShape.circle,
            ),
            child: Icon(Icons.shopping_cart_outlined, color: Colors.white),
          ),
        ],
      ),
    );
  }
}
