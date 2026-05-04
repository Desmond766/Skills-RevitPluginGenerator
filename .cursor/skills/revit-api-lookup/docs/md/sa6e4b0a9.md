---
kind: method
id: M:Autodesk.Revit.DB.Lighting.LightType.GetLightType(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/2cf4fd38-92b9-cc32-12d8-b08851669d1d.htm
---
# Autodesk.Revit.DB.Lighting.LightType.GetLightType Method

Creates a light type object from the given document and family type ID

## Syntax (C#)
```csharp
public static LightType GetLightType(
	Document document,
	ElementId typeId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document the typeId is from
- **typeId** (`Autodesk.Revit.DB.ElementId`) - The ID of the light family type

## Returns
The newly created LightType object

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId is the argument that is being validated
 The ElementId is not valid because it is not for a light element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

