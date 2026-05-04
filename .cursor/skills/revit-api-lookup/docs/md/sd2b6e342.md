---
kind: type
id: T:Autodesk.Revit.DB.Structure.RebarInSystem
source: html/c0bd03fa-78f4-eb67-54e8-e28368e94beb.htm
---
# Autodesk.Revit.DB.Structure.RebarInSystem

Represents a rebar element that is part of a system.

## Syntax (C#)
```csharp
public class RebarInSystem : Element
```

## Remarks
A RebarInSystem element is part of another element, the "system",
 which controls most of its properties. The system elements
 are AreaReinforcement and PathReinforcement.
 Only a few properties of RebarInSystem
 are modifiable. Otherwise, the appearance and behavior of RebarInSystem
 elements is identical to Rebar elements. RebarInSystem elements may be
 converted to Rebar elements by removing the system element.

