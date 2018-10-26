# AuthetificationAWS
Développement de deux web services l'authentification et l'autorisation basés sur le mode d'authentification de Aws Rest    

Cette solution vous propose deux web services 'authenticate' et 'confidentials' (controller : AuthetificationAWS/Idigao.TestAuthetification.Web/Controllers/Api/AuthentificationController.cs ) se basant sur la technologie asp.net core2 avec 
une architecture modulaire orientée services.
Le service "authenticate" demande l'adresse mail et le mot de passe puis vérifie dans une liste si l'utilisateur existe au non.
Le service "confidentials" prend en paramètre l'adresse mail et récupère dans l'en-tête de la requête, les différentes propriétés nécessaires au calcul de la signature.
L'algorithme utilisé se base sur celui décrit dans [ce lien](https://docs.aws.amazon.com/fr_fr/AmazonS3/latest/dev/RESTAuthentication.html)




