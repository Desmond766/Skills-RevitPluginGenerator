---
kind: method
id: M:Autodesk.Revit.DB.Lighting.LightType.GetLightTypeFromInstance(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/0b28606c-a767-a3ef-725f-4ff3edac2cac.htm
---
# Autodesk.Revit.DB.Lighting.LightType.GetLightTypeFromInstance Method

Creates a light type object from the given document and element ID

## Syntax (C#)
```csharp
public static LightType GetLightTypeFromInstance(
	Document document,
	ElementId instanceId
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document the instanceId is from
- **instanceId** (`Autodesk.Revit.DB.ElementId`) - The ID of the light fixture instance

## Returns
The newly created LightType object

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The ElementId is the argument that is being validated
 The ElementId is not valid because it is not for a light element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

