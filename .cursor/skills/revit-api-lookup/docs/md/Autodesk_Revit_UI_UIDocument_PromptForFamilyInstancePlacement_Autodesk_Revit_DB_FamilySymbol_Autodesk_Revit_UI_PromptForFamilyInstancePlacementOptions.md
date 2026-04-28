---
kind: method
id: M:Autodesk.Revit.UI.UIDocument.PromptForFamilyInstancePlacement(Autodesk.Revit.DB.FamilySymbol,Autodesk.Revit.UI.PromptForFamilyInstancePlacementOptions)
source: html/619d8d3f-ac64-26bf-cd82-0f6c37221367.htm
---
# Autodesk.Revit.UI.UIDocument.PromptForFamilyInstancePlacement Method

Prompts the user to place instances of the specified FamilySymbol.

## Syntax (C#)
```csharp
public void PromptForFamilyInstancePlacement(
	FamilySymbol familySymbol,
	PromptForFamilyInstancePlacementOptions options
)
```

## Parameters
- **familySymbol** (`Autodesk.Revit.DB.FamilySymbol`) - The FamilySymbol.
- **options** (`Autodesk.Revit.UI.PromptForFamilyInstancePlacementOptions`) - The PromptForFamilyInstancePlacementOptions, to place the family instance according to the options.

## Remarks
This method opens its own transaction, so it's not permitted to be invoked in an active transaction.
In a single invocation, the user can place multiple instances of the input family type until they finish the 
placement (with Cancel or ESC or a click elsewhere in the UI). The user will not be permitted to change the type to be placed. 
Users are not permitted to change the active view during this placement operation (the operation will be completed).
 This method differs from PostRequestForElementTypePlacement(ElementType) in that it will execute immediately
within the current API context and return to the application when the user completes or cancels the operation. However,
it does not allow the user access to user interface options and settings related to the placement.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when 
the family symbol should be of category OST_DuctTerminal because PlaceAirTerminalOnDuct in options is true,
or the sketch gallery options in options is invalid,
or the placement type for the family symbol in options is invalid.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when 
this API method is invoked in an active transaction,
or this document is not active, 
or this is a family document and the instances of this family symbol can not exist in the current family, 
or this family symbol has no command to create instance, 
or the command to create instance is disabled in active view.

