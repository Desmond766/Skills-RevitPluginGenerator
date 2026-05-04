---
kind: method
id: M:Autodesk.Revit.DB.AppearanceAssetElement.Duplicate(System.String)
source: html/96d557aa-e446-49c5-11cd-59fda2459e82.htm
---
# Autodesk.Revit.DB.AppearanceAssetElement.Duplicate Method

Duplicates the appearance asset element.

## Syntax (C#)
```csharp
public AppearanceAssetElement Duplicate(
	string name
)
```

## Parameters
- **name** (`System.String`) - Name of the new appearance asset element - this name must be correctly structured for Revit use and not duplicate the name
 of another appearance asset in the document.

## Returns
The new AppearanceAssetElement.

## Remarks
The asset contained by this element will be duplicated as well. Changes to the duplicated element or its asset do not affect the original element and asset.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - name cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
 -or-
 The given value for name is already in use as an appearance asset name.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

