<%--
  Created by IntelliJ IDEA.
  User: Administrateur
  Date: 30/07/2025
  Time: 15:37
  To change this template use File | Settings | File Templates.
--%>
<%@taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%--<jsp:useBean id="dogs" type="java.util.ArrayList<com.example.exo_chien.model.Dog>" scope="request" />--%>
<html>
<head>
    <title>Title</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-LN+7fdVzj6u52u30Kp6M/trliBMCMKTyK833zpbD+pXdCLuTusPj697FH4R/5mcr" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/js/bootstrap.bundle.min.js" integrity="sha384-ndDqU0Gzau9qJ1lfW4pNLlhNTkCfHzAVBReH9diLvGRem5+R9g2FzA8ZGN954O5Q" crossorigin="anonymous" defer></script>
</head>
<body>
<h1>Liste de Chiens</h1>
<hr>

<c:if test="${dogs.size() > 0}">
    <table class="table table-dark text-center align-middle">
        <thead>
        <tr>
            <th>Nom</th>
            <th>Race</th>
            <th>Date de naissance</th>
            <th>Details</th>
        </tr>
        </thead>
        <tbody>
        <c:forEach var="dog" items="${dogs}" >
            <tr>
                <td>${dog.name}</td>
                <td>${dog.race}</td>
                <td>${dog.birthdate}</td>
                <td><a href="${pageContext.request.contextPath}/dogs/${dog.id}">details</a></td>
            </tr>
        </c:forEach>
        </tbody>
    </table>
</c:if>

<c:if test="${dogs.size() == 0}">
    <p>Aucun chien a presenter</p>
</c:if>
</body>
</html>
