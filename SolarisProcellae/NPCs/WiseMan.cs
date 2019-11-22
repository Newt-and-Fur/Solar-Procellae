using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace SolarisProcellae.NPCs
{
    [AutoloadHead]
    public class WiseMan : ModNPC
    {
        public override string Texture {
            get { return "SolarisProcellae/NPCs/WiseMan"; }
        }

        public override string[] AltTextures
        {
            get { return new[] { "SolarisProcellae/NPCs/WiseMan_Alt" }; }
        }

        public override bool Autoload(ref string name)
        {
            name = "Weiser Man";
            return mod.Properties.Autoload;
        }

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = 25;
            NPCID.Sets.ExtraFramesCount[npc.type] = 9;
            NPCID.Sets.AttackFrameCount[npc.type] = 5;
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
            NPCID.Sets.AttackType[npc.type] = 0;
            NPCID.Sets.AttackTime[npc.type] = 90;
            NPCID.Sets.AttackAverageChance[npc.type] = 30;
            NPCID.Sets.HatOffsetY[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 18;
            npc.height = 40;
            npc.aiStyle = 7; // Town NPC AI Style
            npc.damage = 30;
            npc.defense = 15;
            npc.lifeMax = 15;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Guide;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            // This will allow us to make an NPC spawn if we have a certain item
            for(int k = 0; k < 255; k++)
            {
                Player player = Main.player[k];
                if(!player.active)
                {
                    continue;
                }

                foreach(Item item in player.inventory)
                {
                    if(item.type == mod.ItemType("OldLetter"))
                    {
                        return true;
                    }
                }                
            }
            return false;
        }

        public override string TownNPCName()
        {
            switch(WorldGen.genRand.Next(4))
            {
                case 0:
                    return "Ludwig";
                case 1:
                    return "Honn";
                case 2:
                    return "Wolfgang";
                default: // Default is the default if no other case is true. In this case if the random number is 3 or more
                    return "Berchtold";
            }
        }

        public override string GetChat()
        {
            //int otherNPC = NPC.FindFirstNPC(NPCID.Angler);
           // if(otherNPC >= 0 && Main.rand.NextBool(4))
           // {
            //     return "Did you know that " + Main.npc[otherNPC].GivenName + " is the angler?";
          //  }
            switch(Main.rand.Next(4))
            {
                default:
                    return $"Ich grüsse dich {Main.LocalPlayer.name}, was bring dich zu mir? Willst du etwas kaufen? Du darfst auch gerne meiner Geschichte lauschen!";
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
            button2 = "Geschichte";
            
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if(firstButton)
            {
                // This is makes it a shop
                shop = true;
            }
            else
            {
                Main.npcChatText = $"Du willst also wirklich meine Geschichte hören {Main.LocalPlayer.name}?";
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            // For every slot, you must have these lines.
            shop.item[nextSlot].SetDefaults(mod.ItemType("TMMCItem"));
            nextSlot++;
            // You can have a max of 40?
            shop.item[nextSlot].SetDefaults(mod.ItemType("TMMCTileItem"));
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType("TMMCWallItem"));
            nextSlot++;
            // You can also have conditions
            if(Main.moonPhase == 2) // The Phase of the Moon
            {
                shop.item[nextSlot].SetDefaults(ItemID.MoonCharm);
                nextSlot++;
            }
            if(Main.hardMode) // If in hardmode
            {
                shop.item[nextSlot].SetDefaults(ItemID.GuideVoodooDoll);
                nextSlot++;
            }
            if(Main.LocalPlayer.HasBuff(BuffID.Regeneration)) // If we have a certain buff
            {
                shop.item[nextSlot].SetDefaults(ItemID.RecallPotion);
                nextSlot++;
            }

        }

        public override void NPCLoot()
        {
            Item.NewItem(npc.getRect(), mod.ItemType("TMMCAccessory"));
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 25;
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 30;
            randExtraCooldown = 25;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ProjectileID.DemonScythe;
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 5f;
            randomOffset = 2f;
        }


        // This is for if you want custom spawn conditions
        // This example will check for the TMMCTile and TMMCWall
        public override bool CheckConditions(int left, int right, int top, int bottom)
        {
            int score = 0;
            for(int x = left; x <= right; x++)
            {
                for(int y = top; y <= bottom; y++)
                {
                    int type = Main.tile[x, y].type;
                    if(type == mod.TileType("TMMCTile"))
                    {
                        score++;
                    }
                    if(Main.tile[x, y].wall == mod.WallType("TMMCWall"))
                    {
                        score++;
                    }
                }
            }
            return score >= (right - left) * (bottom - top) / 2;
        }

    }
}