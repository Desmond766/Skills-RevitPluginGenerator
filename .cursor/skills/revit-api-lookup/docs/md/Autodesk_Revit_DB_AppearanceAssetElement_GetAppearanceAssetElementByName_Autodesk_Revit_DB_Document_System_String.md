---
kind: method
id: M:Autodesk.Revit.DB.AppearanceAssetElement.GetAppearanceAssetElementByName(Autodesk.Revit.DB.Document,System.String)
source: html/d1729485-a9f2-b2cd-9084-96227e2cb6d1.htm
---
# Autodesk.Revit.DB.AppearanceAssetElement.GetAppearanceAssetElementByName Method

Gets an AppearanceAssetElement by name.

## Syntax (C#)
```csharp
public static AppearanceAssetElement GetAppearanceAssetElementByName(
	Document doc,
	string name
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - Document containing the AppearanceAssetElement.
- **name** (`System.String`) - Name of the AppearanceAssetElement.

## Returns
The AppearanceAssetElement with the given name, or Nothing nullptr a null reference ( Nothing in Visual Basic) if this element does not exist.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

