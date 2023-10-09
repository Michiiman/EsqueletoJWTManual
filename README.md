# Manual JWT Implementation🤓💻🔒


This project demonstrates the implementation of JSON Web Tokens (JWT) manually, providing you with more control and flexibility over the JWT generation and validation process.

## Why Use Manual JWT?🔒

There are several scenarios where implementing manual JWT can be advantageous, such as:

- Needing fine-grained control over JWT creation and validation.
- Integrating JWT with legacy systems.
- Customizing JWT claims to fit specific application requirements.

## How to Implement Manual JWT⌨️

Follow these steps to implement manual JWT in your project:

1. **Create UserClaims Class:** Define a `UserClaims` class to represent the claims about the user, such as their name, email address, and role. This class will be used when generating JWT tokens.

2. **Create JwtService Class:** Build a `JwtService` class responsible for generating and validating JWT tokens. This class should include methods for token creation and validation.

3. **Generate JWT Token:** When a user authenticates, call the appropriate method in your `JwtService` class to generate a JWT token with the desired claims.

4. **Set JWT Token:** Store the generated JWT token in a cookie or include it in the HTTP headers of subsequent requests. Ensure proper security measures are in place, such as using secure cookies and secure headers.

5. **Validate JWT Token:** On every incoming request, validate the JWT token by using the `JwtService` class to check the token's authenticity and expiration date.

6. **Authorize Access:** Based on the claims present in the JWT token, implement access control logic to determine whether the user is authorized to access specific resources.

## Tips for Implementing Manual JWT Securely 🤓☝️

Here are some best practices to ensure the security of your manual JWT implementation:

- Use a strong and secret security key for signing JWT tokens.
- Set a reasonably **short expiration time** for JWT tokens to minimize their exposure.
- Implement a mechanism to invalidate JWT tokens if they are compromised, such as token revocation lists.

## Example Code

```c#
# Example code snippets

# UserClaims class
public class UserDto
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int RoleIdFk { get; set; }
    public RoleDto Role { get; set; }

}

# Generate Tokens
    public string getTokenLogin(string email, string password)
    {
        Encriptacion encrip = new Encriptacion();
        string fecha = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
        string tokenLogin = encrip.AES256_Encriptar(encrip.AES256_LOGIN_Key, fecha + '#' + email + '#' + encrip.GetSHA256(password));
        return tokenLogin;
    }

    [HttpPost("loginByToken")]
    public async Task<ActionResult> LoginByToken([FromForm] RegisterDto data)
    {
        Services.Login log = new Services.Login();
        User ent = await unitOfWork.Users.GetByEmailAsync(data.Email); // Traemos el objeto que concuerda con el Email.

        if (ent == null)
        {
            return BadRequest("Usuario no encontrado");
        }

        string token = log.LoginByToken(data.LoginToken, ent);

        switch (token)
        {
            case "-1": return BadRequest("Límite de tiempo excedido");
            case "-2": return BadRequest("Usuario o clave incorrectos");
            case "-3": return BadRequest("No se pudo hacer el login, revise los datos enviados");
            default: return Ok(token);
        }
    }
