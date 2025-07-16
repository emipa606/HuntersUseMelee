# GitHub Copilot Instructions for RimWorld Modding Project

## Mod Overview and Purpose

**Mod Name**: HuntersUseMelee

The "HuntersUseMelee" mod is designed to enhance the hunting mechanics in RimWorld by allowing hunters to use melee weapons effectively. This mod is aimed at improving the versatility and realism of hunting in the game, providing players with more tactical choices and enabling better resource management for colonies focused on melee combat.

## Key Features and Systems

- **Melee Weapon Integration**: Hunters can now engage in hunting using melee weapons, making them a viable option for colonies that prioritize melee combat over ranged.
- **Alert System Enhancement**: The mod alters the game's alert system to account for melee-equipped hunters, reducing unnecessary alerts about lacking appropriate hunting weapons.
- **Dynamic Settings**: Players can configure the behavior of melee-hunting through mod settings, allowing custom configurations to fit different playstyles.

## Coding Patterns and Conventions

- **Class Naming**: Use PascalCase for classes with meaningful names that reflect their purpose, e.g., `HuntersUseMeleeMain`.
- **Method Visibility**: Expose methods with appropriate access modifiers. Internal or private where necessary to encapsulate functionality.
- **Commenting and Documentation**: Include XML comments for classes and methods to provide clear documentation for their purpose and usage within the mod.

## XML Integration

Although the summary does not contain specific XML data, XML is typically used in RimWorld mods for defining items, factions, and game settings. For future integration:

- Utilize XML to configure mod settings that can be read and modified through C# classes.
- Ensure XML keys correspond accurately to their C# counterparts for seamless integration and accessibility.

## Harmony Patching

Harmony is used to patch existing game methods, allowing the mod to modify base game behavior without directly altering core files:

- **Structure**: All patches should be organized in classes within files such as `Patch_HasHuntingWeapon.cs` and `Patch_HuntersLacksWeaponAlert.cs`.
- **Best Practices**: When creating patches, ensure they are reversible and do not produce conflicts or errors when the mod is toggled.
- **Attributes**: Use attributes such as `[HarmonyPatch]` to define which methods are being patched and `[HarmonyPostfix]` or `[HarmonyPrefix]` to control execution order.

## Suggestions for Copilot

When using GitHub Copilot for further development on this RimWorld mod, consider the following:

- **Boilerplate Generation**: Utilize Copilot for generating repetitive boilerplate code such as class structures, Harmony patch definitions, and method scaffolding.
- **XML Handling**: Let Copilot assist with serializing and deserializing XML for settings and configurations.
- **Refactoring Assistance**: Leverage Copilot for refactoring code, ensuring it adheres to best practices and improves maintainability.
- **Error Checking**: Integrate Copilot in finding common errors in code such as null reference exceptions and logic anomalies in patches.

By adhering to these guidelines, the mod development process will be streamlined, and the resulting enhancements to RimWorld's gameplay will be both robust and user-friendly.
