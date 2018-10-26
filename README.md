# AuthetificationAWS
Développement de deux web service l'authentification et l'autorisation base sur algorithmie Aws Rest    

Cette solution vous propose deux web services 'authenticate' et 'confidentials' se basant sur la technologie asp.net core2 avec 
une architeture modulaire orientér services.
Le service "authenticate" demande l'adresse mail et le mot de passe puis verifie dans une liste si l'utilisateur existe au non.
Le service confidentials prend en parametre l'adresse email et recupère dans l'en tête de la requete les différentes propriétés nécessaires
au calcul de la signature.
L'algorithme utilisé se base sur celui decrit dans [ce lien](https://docs.aws.amazon.com/fr_fr/AmazonS3/latest/dev/RESTAuthentication.html)




