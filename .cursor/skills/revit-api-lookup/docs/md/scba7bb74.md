---
kind: type
id: T:Autodesk.Revit.DB.WallType
source: html/aa685433-b426-5e4f-bee1-e3487bb59518.htm
---
# Autodesk.Revit.DB.WallType

Represents a specific type of wall, such as 'Generic - 8"'.

## Syntax (C#)
```csharp
public class WallType : HostObjAttributes
```

## Remarks
All wall type objects available in the project can be retrieved from the Document object
 via the WallTypes property. Every Wall object has a WallType property that returns the a
 WallType object representing the type. This same WallType property can also be used to
 change the type of the wall by setting it to a different type.

