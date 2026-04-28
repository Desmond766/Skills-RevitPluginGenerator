---
kind: method
id: M:Autodesk.Revit.DB.BrowserOrganization.GetFolderItems(Autodesk.Revit.DB.ElementId)
source: html/6d61981d-4d9c-477c-a85a-6ae375bc8cfc.htm
---
# Autodesk.Revit.DB.BrowserOrganization.GetFolderItems Method

Returns a collection of leaf FolderItemInfo objects each containing the given element Id.

## Syntax (C#)
```csharp
public IList<FolderItemInfo> GetFolderItems(
	ElementId elementId
)
```

## Parameters
- **elementId** (`Autodesk.Revit.DB.ElementId`) - Element id located at a leaf position in the project browser.

## Returns
An array of FolderItemInfo objects.

## Remarks
Each returned FolderItemInfo includes the folder name and the corresponding folder parameter Id.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - elementId is not a valid Element identifier.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

