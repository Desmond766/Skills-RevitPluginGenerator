---
kind: method
id: M:Autodesk.Revit.DB.Architecture.MultistoryStairs.ConnectLevels(System.Collections.Generic.ISet{Autodesk.Revit.DB.ElementId})
source: html/e6734f94-80de-fedd-e972-488899569085.htm
---
# Autodesk.Revit.DB.Architecture.MultistoryStairs.ConnectLevels Method

Extends the multistory stairs by connecting input levels.

## Syntax (C#)
```csharp
public void ConnectLevels(
	ISet<ElementId> levelIds
)
```

## Parameters
- **levelIds** (`System.Collections.Generic.ISet < ElementId >`) - The level ids.

## Remarks
The added stairs will be categorized into different groups based on level heights automatically. Stairs with the same level height are considered a group and can be edited together.
 You cannot connect the levels between standard stairs top and bottom or already connected.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This multistory stairs cannot connect to one or more members of levelIds.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

