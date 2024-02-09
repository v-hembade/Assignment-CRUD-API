# Assignment-CRUD-API

Implementation details
1.	POST is used to login user 
a.	JWT Token for authentication
b.	All endpoints except login must be authorized 
2.	GET is used to get all persons (Access only for Admin User)
a.	Server should answer with status code 200 and all users records
3.	GET single user
a.	Server should answer with status code 200 and record with id === userId if it exists
b.	Server should answer with status code 400 and corresponding message if userId is invalid (not uuid)
c.	Server should answer with status code 404 and corresponding message if record with id === userId doesn't exist


4.	POST is used to create record about new user (Access only for Admin Users)
a.	Server should answer with status code 201 and newly created record
b.	Server should answer with status code 400 and corresponding message if request body does not contain required fields
5.	PUT is used to update existing users 
a.	Server should answer with status code 200 and updated record
b.	Server should answer with status code 400 and corresponding message if userId is invalid (not uuid)
c.	Server should answer with status code 404 and corresponding message if record with id === userId doesn't exist
d.	If the logged-in user is an admin, they can update any user data. However, if the logged-in user is a non-admin, they cannot change other users' data.
6.	DELETE is used to delete existing user from database (Access only for Admin Users)
a.	Server should answer with status code 204 if the record is found and deleted
b.	Server should answer with status code 400 and corresponding message if userId is invalid (not uuid)
c.	Server should answer with status code 404 and corresponding message if record with id === userId doesn't exist
