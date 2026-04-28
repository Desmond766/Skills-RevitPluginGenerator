---
kind: type
id: T:Autodesk.Revit.DB.RoofType
source: html/00b5948e-1cb6-4f3b-acc1-9f000e8cc40d.htm
---
# Autodesk.Revit.DB.RoofType

Represents a specific type of roof.

## Syntax (C#)
```csharp
public class RoofType : HostObjAttributes
```

## Remarks
All roof type objects available in the project can be retrieved from the Document object
 via the RoofTypes property. Every Roof object has a RoofType property that returns a
 RoofType object representing the type. This same RoofType property can also be used to
 change the type of the roof by setting it to a different type.

