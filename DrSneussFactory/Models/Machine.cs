using System.Collections.Generic;

namespace DrSneussFactory.Models
{
  public class Machine
  {
    public Machine()
    {
      this.Engineers = new HashSet<EngineerMachine>();
    }

    public int MachineId { get; set; }
    public string Name { get; set; }
    public ICollection<EngineerMachine> Engineers { get;}
  }
}