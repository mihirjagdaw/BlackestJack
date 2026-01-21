# BlackestJack - A Blackjack Learning Experience

## 🎯 Project Vision
BlackestJack is more than just a card game simulator—it's an educational tool disguised as entertainment. The project evolves through three distinct phases, each building upon the last to create a comprehensive learning and gaming experience centered around Blackjack.

## 📋 Project Phases
### Phase 1: Core Blackjack Game ✅ In Progress
A fully-functional console-based Blackjack implementation featuring:

✅ 8-deck shoe system (casino-style)

✅ Proper Blackjack rules and card handling

✅ Player vs. Dealer gameplay

✅ Ace value calculation (1 or 11)

✅ Blackjack detection and payout logic

✅ Basic betting system

### Phase 2: Learning Mode 🎓
An interactive tutorial system that teaches "perfect" Blackjack strategy through gameplay:

Strategy Coach: Real-time suggestions based on your hand vs. dealer's upcard

Mistake Analysis: Explanation of why certain moves are optimal

Basic Strategy Chart: Visual reference showing statistically best moves

Practice Mode: Risk-free environment to hone skills

Progress Tracking: Monitor improvement over time

### Phase 3: Endless Mode ♾️
Test your skills in a high-stakes, progressive gameplay experience:

Risk Assessment: Learn when to walk away while you're ahead

Bankroll Management: Practice responsible gambling habits

Progressive Difficulty: Adapting AI and changing conditions

High Score System: Track how far you can go before "losing it all"

Statistics Dashboard: Review your decision-making patterns

## 🎮 Future Vision: "Night Out" 3D Experience
The ultimate goal is to transform BlackestJack into an immersive 3D narrative game:

### Concept Overview
Experience a night out with friends at a casino, blending Blackjack gameplay with social interaction and storytelling.

### Key Features Planned:
Unique NPC Companions: Each with distinct personalities, backstories, and reactions to your gameplay

Dynamic Dialogue System: Conversations that change based on your decisions and outcomes

Stylized Art Direction: A unique visual style capturing the atmosphere of a night out

Branching Narratives: Your Blackjack success/failure influences the story's direction

Mini-games & Social Interactions: Beyond Blackjack, experience the full night out

Morality & Consequence System: Explore themes of risk, reward, and responsibility

## 🛠️ Technical Implementation
### Current Architecture:
csharp
- Person.cs          # Player/Dealer logic and hand management
- Card.cs            # Card object definition
- BlackestJack.cs    # Game rules and deck management
- Program.cs         # Main game loop and UI
### Technology Stack:
Language: C# (.NET Core/6+)

Platform: Console Application (Phase 1), transitioning to Unity (Future Phases)

Architecture: Object-Oriented Design with clear separation of concerns

## 📖 Educational Value
This project serves dual purposes:

For Users: Learn Blackjack strategy, probability, and responsible risk management in an engaging way

For Developers: A case study in game development, from console apps to 3D experiences, with progressive complexity

## 🎯 Learning Objectives
Through this project, I aim to master:

Game state management and rule implementation

AI behavior for dealer and future NPCs

User interface progression (console → 3D)

Educational game design principles

Narrative integration with gameplay mechanics

## 🚀 Getting Started
### Prerequisites:
.NET 6.0 SDK or later

Visual Studio 2022 or VS Code with C# extensions

## Running the Current Version:
bash
`git clone [repository-url]`
`cd BlackestJack`
`dotnet run`
## 🔮 Roadmap
### Short-term (Next 2-4 weeks):
Complete Phase 1 with polished console interface

Add betting system and chip management

Implement basic statistics tracking

Create strategy helper foundation

### Medium-term (1-3 months):
Develop Learning Mode with interactive tutorials

Implement Basic Strategy AI suggestions

Add save/load functionality for progress

Create visual strategy charts

### Long-term (3-6 months):
Build Endless Mode with progressive challenges

Transition to Unity for 3D development

Create initial NPC characters and dialogue system

Develop prototype of "Night Out" narrative

## 🤝 Contributing
While currently a personal learning project, the code is structured to be understandable and modular. Feedback and suggestions are welcome as the project evolves.

## 📝 License
This project is developed for educational purposes. All code is open for learning and inspiration.

"The goal isn't just to win at Blackjack, but to understand the game well enough to know when to stop playing."

Current Status: Phase 1 Development - Core Blackjack Mechanics 🃏

Last Updated: [Current Date]
Version: 0.1.0 (Console Prototype)
