---
kind: type
id: T:Autodesk.Revit.DB.Structure.Hub
source: html/67b4e27c-7f91-f233-681c-97ce858c6a65.htm
---
# Autodesk.Revit.DB.Structure.Hub

Represents a connection between two or more Autodesk Revit Elements.

## Syntax (C#)
```csharp
public class Hub : Element
```

## Remarks
Elements connected via a Hub do not refer directly to each other - they each refer to the Hub that keeps all the connectivity information. Hubs connect only structural Analytical Model Elements.

