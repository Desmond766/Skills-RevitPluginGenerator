---
kind: method
id: M:Autodesk.Revit.DB.ParameterDownloadOptions.#ctor(System.Collections.Generic.ISet{Autodesk.Revit.DB.ElementId},System.Boolean,System.Boolean,Autodesk.Revit.DB.ForgeTypeId)
source: html/fed9a4a4-fb8e-6d5b-23e1-73e53d1be823.htm
---
# Autodesk.Revit.DB.ParameterDownloadOptions.#ctor Method

Creates a new ParameterDownloadOptions instance.
 Category bindings are represented by an ElementIdSet populated with category identifiers.

## Syntax (C#)
```csharp
public ParameterDownloadOptions(
	ISet<ElementId> categories,
	bool isInstance,
	bool visible,
	ForgeTypeId groupTypeId
)
```

## Parameters
- **categories** (`System.Collections.Generic.ISet < ElementId >`) - The category identifiers.
- **isInstance** (`System.Boolean`) - True if binding to Element instances, false if binding to Element types.
- **visible** (`System.Boolean`) - True if the parameter is visible to the user, false if it is hidden and accessible only via the API.
- **groupTypeId** (`Autodesk.Revit.DB.ForgeTypeId`) - Properties palette group identifier.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

