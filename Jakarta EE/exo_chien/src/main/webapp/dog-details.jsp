<%--
  Created by IntelliJ IDEA.
  User: Administrateur
  Date: 30/07/2025
  Time: 15:43
  To change this template use File | Settings | File Templates.
--%>
<%@taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%--<jsp:useBean id="dog" type="com.example.exo_chien.model.Dog" scope="request" />--%>

<html>
<head>
    <title>Title</title>
</head>
<body>
<h1>${dog.name}</h1>
<p>Race : ${dog.race}</p>
<p>Birthdate : ${dog.birthdate}</p>
</body>
</html>
