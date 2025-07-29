<%--
  Created by IntelliJ IDEA.
  User: Administrateur
  Date: 29/07/2025
  Time: 15:28
  To change this template use File | Settings | File Templates.
--%>
<%@taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
  <title>Formulaire</title>
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/css/bootstrap.min.css" rel="stylesheet"
        integrity="sha384-LN+7fdVzj6u52u30Kp6M/trliBMCMKTyK833zpbD+pXdCLuTusPj697FH4R/5mcr" crossorigin="anonymous">
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/js/bootstrap.bundle.min.js"
          integrity="sha384-ndDqU0Gzau9qJ1lfW4pNLlhNTkCfHzAVBReH9diLvGRem5+R9g2FzA8ZGN954O5Q" crossorigin="anonymous"
          defer></script>
</head>
<body>
<h1>Formulaire</h1>

<form action="cats" method="post">
  <div>
    <label for="name">Name :</label>
    <input type="text" id="name" name="name">
  </div>
  <div>
    <label for="race">Race:</label>
    <input type="text" id="race" name="race">
  </div>
  <div>
    <label for="favoriteFood">Favorite food :</label>
    <input type="text" id="favoriteFood" name="favoriteFood">
  </div>
  <div>
    <label for="birthdate">Birthdate :</label>
    <input type="date" id="birthdate" name="birthdate">
  </div>
  <button>Ajouter</button>
  <button type="reset">Annuler</button>
</form>

</body>
</html>
