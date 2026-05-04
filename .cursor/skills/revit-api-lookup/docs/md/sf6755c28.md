---
kind: method
id: M:Autodesk.Revit.DB.Steel.SteelElementProperties.AddFabricationInformationForRevitElements(Autodesk.Revit.DB.Document,System.Collections.Generic.IList{Autodesk.Revit.DB.ElementId})
source: html/e810d6c5-90af-0fe2-4802-338546b16953.htm
---
# Autodesk.Revit.DB.Steel.SteelElementProperties.AddFabricationInformationForRevitElements Method

This method adds fabrication information to the given elements.

## Syntax (C#)
```csharp
public static IList<ElementId> AddFabricationInformationForRevitElements(
	Document aDoc,
	IList<ElementId> elementIds
)
```

## Parameters
- **aDoc** (`Autodesk.Revit.DB.Document`) - Document containing the given elements ids.
- **elementIds** (`System.Collections.Generic.IList < ElementId >`) - Ids of the elements to which we want to add fabrication information.

## Returns
Ids of the elements for which we couldn't add fabrication information.

## Remarks
You can add fabrication information to connections, beams, columns, braces, walls, floors and foundations.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

