using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISubject {

    void AddObserver(IObserver obs);
    void RemoveObserver(IObserver obs);
    void Notify(bool movementChange);
}
