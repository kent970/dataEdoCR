//Uwaga ogólna - operacje na datacontexcie powinny byc raczej nie w kontrolerze tylko w jakims serwisie wywoływanym z kontrolera. Kontroler powinien zajmować się tylko wywołaniem tego serwisu
[HttpPost ("delete/{id}")]
//Jeśli usuwamy można uzyc HttpDelete
public void Delete (uint id)
//Jeśli chcemy zwracać Ok() typem zwracanym metody powinien być np. IActionResult
{
User user = _context.Users. FirstOrDefault (user => user.Id == id);
//zmienna user mozna zadeklarowac jako var a potem zainicjowac
//zakladajac ze id jest unikalne mozna tez uzyc SingleOrDefault
_context.Users.Remove(user);
_context.SaveChanges();
Debug.WriteLine($"The user with Login={user.login} has been deleted.") ;
//tu lepiej uzyc Loggera
return Ok();
}