---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainer.HasPresentationOverrides(Autodesk.Revit.DB.View)
source: html/cc0e04ac-56a9-f1a5-cae8-9962b0aa60a4.htm
---
# Autodesk.Revit.DB.Structure.RebarContainer.HasPresentationOverrides Method

Identifies if any RebarContainerItem of this RebarContainer has overridden default presentation settings for the given view.

## Syntax (C#)
```csharp
public bool HasPresentationOverrides(
	View dBView
)
```

## Parameters
- **dBView** (`Autodesk.Revit.DB.View`) - The view.

## Returns
True if if any RebarContainerItem of this RebarContainer has overridden default presentation settings, false otherwise.

## Remarks
Default presentation settings can be overriden using [!:Autodesk::Revit::DB::Structure::RebarContainerItem::SetBarHiddenStatus] , [!:Autodesk::Revit::DB::Structure::RebarContainerItem::SetPresentationMode] methods

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

