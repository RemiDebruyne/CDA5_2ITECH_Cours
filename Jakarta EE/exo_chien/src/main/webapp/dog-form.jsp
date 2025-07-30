<%--
  Created by IntelliJ IDEA.
  User: Administrateur
  Date: 30/07/2025
  Time: 09:25
  To change this template use File | Settings | File Templates.
--%>
<%@taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%--<jsp:useBean id="dogs" type="java.util.ArrayList<com.example.exo_chien.model.Dog>" scope="request" />--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Les chiens</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-LN+7fdVzj6u52u30Kp6M/trliBMCMKTyK833zpbD+pXdCLuTusPj697FH4R/5mcr" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/js/bootstrap.bundle.min.js" integrity="sha384-ndDqU0Gzau9qJ1lfW4pNLlhNTkCfHzAVBReH9diLvGRem5+R9g2FzA8ZGN954O5Q" crossorigin="anonymous" defer></script>
</head>
<body>

<main class="container">
    <hr>

    <h2>Formulaire d'ajout d'un chien</h2>

    <form action="${pageContext.request.contextPath}/dogs" method="post">
        <div>
            <label for="name">Nom :</label>
            <input type="text" id="name" name="name">
        </div>
        <div>
            <label for="race">Race :</label>
            <input type="text" id="race" name="race">
        </div>
        <div>
            <label for="birthdate">Date de Naissance :</label>
            <input type="date" id="birthdate" name="birthdate">
        </div>
        <button>Ajouter</button>
        <button type="reset">Annuler</button>
    </form>


</main>

</body>
</html>
