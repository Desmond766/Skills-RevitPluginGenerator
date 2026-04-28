---
kind: method
id: M:Autodesk.Revit.DB.BindingMap.Erase(Autodesk.Revit.DB.Definition)
source: html/f60e2b2b-e720-07fe-e1a5-1fc2569c0ce3.htm
---
# Autodesk.Revit.DB.BindingMap.Erase Method

This method is used to erase one item in the map.

## Syntax (C#)
```csharp
public override int Erase(
	Definition key
)
```

## Parameters
- **key** (`Autodesk.Revit.DB.Definition`)

## Remarks
The method Erase inherited from base class is not permitted for this class. 
A Autodesk::Revit::Exceptions::InvalidOperationException will be thrown. Use Remove() instead to remove the binding 
from the Revit session and from the map.

