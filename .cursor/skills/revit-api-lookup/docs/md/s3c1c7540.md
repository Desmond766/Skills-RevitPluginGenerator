---
kind: method
id: M:Autodesk.Revit.DB.CurtainGrid.ChangePanelType(Autodesk.Revit.DB.Element,Autodesk.Revit.DB.ElementType)
source: html/00a3e500-c61a-4f6a-7a98-7340bef88f4c.htm
---
# Autodesk.Revit.DB.CurtainGrid.ChangePanelType Method

Change the type of a curtain panel.

## Syntax (C#)
```csharp
public Element ChangePanelType(
	Element panel,
	ElementType newSymbol
)
```

## Parameters
- **panel** (`Autodesk.Revit.DB.Element`) - The panel to be changed, it can be a type of Panel or Wall .
- **newSymbol** (`Autodesk.Revit.DB.ElementType`) - The new symbol, it may be of PanelType or WallType when the panel is hosted in a curtain wall. 
The new symbol can only be of type PanelType if the Panel is hosted in a curtain system.

## Returns
If operation succeeds, the modified panel element is returned.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the input symbol can't be used for the panel.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the type change failed.

