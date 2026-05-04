---
kind: method
id: M:Autodesk.Revit.DB.Lighting.LightGroupManager.GetLightGroupManager(Autodesk.Revit.DB.Document)
source: html/38eb96b7-6c03-3918-a914-99fa0b065851.htm
---
# Autodesk.Revit.DB.Lighting.LightGroupManager.GetLightGroupManager Method

Creates a light group manager object from the given document

## Syntax (C#)
```csharp
public static LightGroupManager GetLightGroupManager(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document the manager is from

## Returns
The newly created Light group manager object

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The document is not valid because it is not a project (rvt) document
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

