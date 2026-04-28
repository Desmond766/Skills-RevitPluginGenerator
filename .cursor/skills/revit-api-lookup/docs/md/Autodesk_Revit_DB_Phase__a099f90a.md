---
kind: type
id: T:Autodesk.Revit.DB.Phase
source: html/ab01f390-a8e8-c21c-b2d0-6dd21056cdec.htm
---
# Autodesk.Revit.DB.Phase

Represents a phase in the life of a building.

## Syntax (C#)
```csharp
public class Phase : Element
```

## Remarks
The lifetime of an element within a building can be controlled by using phases.
Each element will have a construction phase but only those elements that have a finite
lifetime will have a destruction phase. All the phases within a project can be retrieved
from the Document object.

