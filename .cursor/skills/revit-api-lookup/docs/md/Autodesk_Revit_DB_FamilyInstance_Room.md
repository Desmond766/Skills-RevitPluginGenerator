---
kind: property
id: P:Autodesk.Revit.DB.FamilyInstance.Room
zh: 房间
source: html/37944e7a-f298-9c25-20bb-9c0c1da46f41.htm
---
# Autodesk.Revit.DB.FamilyInstance.Room Property

**中文**: 房间

The room in which the instance is located (during the last phase of the project).

## Syntax (C#)
```csharp
public Room Room { get; }
```

## Remarks
This property will be the first room encountered that contains the instance. If more than 
one room includes this point in its volume only the first one is returned.
If no room is found that contains the instance, or if phase does not apply to this FaimlyInstance, 
this property is Nothing nullptr a null reference ( Nothing in Visual Basic) .
This property should not be used for door or window instances, which are placed on the boundary or
between rooms. Use the FromRoom and ToRoom properties instead.

