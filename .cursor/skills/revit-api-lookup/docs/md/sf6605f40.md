---
kind: method
id: M:Autodesk.Revit.DB.ExternalDefinitionCreationOptions.#ctor(System.String,Autodesk.Revit.DB.ForgeTypeId)
source: html/449e1cdb-ae48-6474-4da5-979c14b408f8.htm
---
# Autodesk.Revit.DB.ExternalDefinitionCreationOptions.#ctor Method

Constructs the options using a specified name and type.

## Syntax (C#)
```csharp
public ExternalDefinitionCreationOptions(
	string name,
	ForgeTypeId dataType
)
```

## Parameters
- **name** (`System.String`) - The name of the parameter definition to be created.
- **dataType** (`Autodesk.Revit.DB.ForgeTypeId`) - The identifier of either a spec or a category.
 A category identifier indicates a Family Type parameter of that category.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given identifier is neither a spec nor a category.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

