---
kind: method
id: M:Autodesk.Revit.DB.GeometryObject.Equals(System.Object)
source: html/26d6c913-b5b6-436f-dee9-19ceca7e53c6.htm
---
# Autodesk.Revit.DB.GeometryObject.Equals Method

Determines whether the specified Object is equal to the current Object .

## Syntax (C#)
```csharp
public override bool Equals(
	Object obj
)
```

## Parameters
- **obj** (`System.Object`) - Another object.

## Remarks
This compares the internal identifiers of the geometry, and doesn't compare them geometrically.

