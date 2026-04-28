---
kind: method
id: M:Autodesk.Revit.DB.FabricationConfiguration.GetItemFolders
source: html/d283e079-1113-f185-e9c0-d40fada72391.htm
---
# Autodesk.Revit.DB.FabricationConfiguration.GetItemFolders Method

Gets a list of every fabrication item folder in the fabrication item folder structure.

## Syntax (C#)
```csharp
public IList<FabricationItemFolder> GetItemFolders()
```

## Returns
Returns a list of every fabrication item folder in the fabrication item folder structure.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The current fabrication configuration is not connected and updated to source configuration. Reload and try again.

