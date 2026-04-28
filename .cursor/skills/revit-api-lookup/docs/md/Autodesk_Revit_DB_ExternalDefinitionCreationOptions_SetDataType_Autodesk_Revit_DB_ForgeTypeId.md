---
kind: method
id: M:Autodesk.Revit.DB.ExternalDefinitionCreationOptions.SetDataType(Autodesk.Revit.DB.ForgeTypeId)
source: html/2996abcb-0293-a469-6669-58fd39084594.htm
---
# Autodesk.Revit.DB.ExternalDefinitionCreationOptions.SetDataType Method

Sets the parameter's data type.

## Syntax (C#)
```csharp
public void SetDataType(
	ForgeTypeId dataType
)
```

## Parameters
- **dataType** (`Autodesk.Revit.DB.ForgeTypeId`) - The identifier of either a spec or a category.
 A category identifier indicates a Family Type parameter of that category.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given identifier is neither a spec nor a category.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

