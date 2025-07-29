<%--
  Created by IntelliJ IDEA.
  User: Administrateur
  Date: 29/07/2025
  Time: 16:02
  To change this template use File | Settings | File Templates.
--%>
<%@taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<jsp:useBean id="cats" type="java.util.ArrayList<com.example.exo_3.models.Cat>" scope="request"/>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Title</title>
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/css/bootstrap.min.css" rel="stylesheet"
        integrity="sha384-LN+7fdVzj6u52u30Kp6M/trliBMCMKTyK833zpbD+pXdCLuTusPj697FH4R/5mcr" crossorigin="anonymous">
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/js/bootstrap.bundle.min.js"
          integrity="sha384-ndDqU0Gzau9qJ1lfW4pNLlhNTkCfHzAVBReH9diLvGRem5+R9g2FzA8ZGN954O5Q" crossorigin="anonymous"
          defer></script>
</head>
<body>

<c:if test="${cats.size() > 0}">
  <table class="table">
    <thead>
    <tr>
      <th scope="col">#</th>
      <th scope="col">name</th>
      <th scope="col">race</th>
      <th scope="col">Favorite food</th>
      <th scope="col">Birth date</th>
    </tr>
    </thead>
    <tbody>
    <c:forEach var="cat" items="${cats}" varStatus="loop">
      <tr>
        <th scope="row">${loop.index}</th>
        <td>${cat.name}</td>
        <td>${cat.race}</td>
        <td>${cat.favoriteFood}</td>
        <td>${cat.birthdate}</td>
      </tr>
    </c:forEach>


    </tbody>
  </table>
</c:if>
<c:if test="${cats.size() == 0}">
  <p>Il n'y a pas de chats</p>
</c:if>
</body>
</html>
