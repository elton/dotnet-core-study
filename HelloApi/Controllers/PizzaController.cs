// Copyright 2021 Elton Zheng
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using HelloAPI.Models;
using HelloAPI.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
  public PizzaController() {

  }

  // GET all action
  [HttpGet]
  public ActionResult<List<Pizza>> GetAll()
  {
    return PizzaService.GetAll();
  }

  // GET by Id action
  [HttpGet("{id}")]
  public ActionResult<Pizza> Get(int id)
  {
    var pizza = PizzaService.Get(id);

    if(pizza == null)
        return NotFound();

    return pizza;
  }

  // Create action
  [HttpPost]
  public IActionResult Create(Pizza pizza)
  {            
    PizzaService.Add(pizza);
    return CreatedAtAction(nameof(Create), new { id = pizza.Id }, pizza);
  }

  // Update action
  [HttpPut("{id}")]
  public IActionResult Update(int id, Pizza pizza)
  {
    if (id != pizza.Id)
        return BadRequest();

    var existingPizza = PizzaService.Get(id);
    if(existingPizza is null)
        return NotFound();

    PizzaService.Update(pizza);           

    return NoContent();
  }

  // Delete action
  [HttpDelete("{id}")]
  public IActionResult Delete(int id)
  {
    var pizza = PizzaService.Get(id);

    if (pizza is null)
        return NotFound();

    PizzaService.Delete(id);

    return NoContent();
  }
}